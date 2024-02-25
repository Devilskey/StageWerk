let isToCollector;
let IgnoreUnhandledRejectionFromCollector = false;

let settings = {
  ApiUrl: 'http://collector.monitor.nl/collector',
  ContentType: 'application/json',
  Language: 'React / typescript',
  ApiKey: '',
};

const sendPost = async (json) => {
  const connectionSettings = {
    method: 'POST',
    headers: { 'Content-Type': settings.ContentType },
    body: JSON.stringify(json),
  };
  isToCollector = true;
  await fetch(settings.ApiUrl, connectionSettings);
  isToCollector = false;
};

// Checks if there is a ErrorSource else gets the source from error
const setErrorSource = (
  _errorSources,
  _error,
) => {
  if (_errorSources === undefined) {
    const callerLine = `${_error.stack?.split('\n')[1]}`;
    const index = callerLine.indexOf('at ');
    const clean = callerLine.slice(index + 2, callerLine.length);
    return clean;
  }
  return _errorSources.toString();
};

// check if there is a error message or if it needs to use error.message
const setErrorMessage = (
  _errorMessage,
  _error,
) => {
  if (_errorMessage === undefined) return _error.message;
  return _errorMessage.toString();
};

// sends errors to the collector api
const sendErrorDataToCollector = (
  _error,
  _errorMessage,
  _errorSources,
  _errorLineNumber = "",
  _errorColumNumber = "",
) => {
  if (_error instanceof Error) {
    const parameters = {
      additionalProp1: ``,
      additionalProp2: ``,
      additionalProp3: ``,
    };

    const errorJsonModel = {
      ThrownAt: new Date().toISOString(),
      LogLevel: 4,
      Message: `${setErrorMessage(_errorMessage, _error)}`,
      Parameters: parameters,
      ExceptionType: _error.name,
      Source: `Line Number: ${_errorLineNumber}, Column Number: ${_errorColumNumber}, Stack Trace: ${_error.stack}}`,
      Language: settings.Language,
      Claims: [],
    };
    
    sendPost(errorJsonModel);
    isToCollector = false;
  }
};

const sendConsoleDataToCollector = (
  _logLevels,
  _ExceptionType,
  _ConsoleMessage,
) => {
  const parameters = {
    additionalProp1: '',
    additionalProp2: '',
    additionalProp3: '',
  };
  let GivenLogLevel = 4;
  if (_logLevels !== null) GivenLogLevel = _logLevels;

  const errorJsonModel = {
    ThrownAt: new Date().toISOString(),
    LogLevel: GivenLogLevel,
    Message: _ConsoleMessage,
    Parameters: parameters,
    ExceptionType: _ExceptionType,
    Source: '',
    Language: settings.Language,
    Claims: [],
  };
  sendPost(errorJsonModel);
};

// overrides the console so it sends error messages to the collector
const consoleMessageOverride = () => {
  const originalConsoleError = console.error;
  const originalConsoleLog = console.log;
  const originalConsoleWarn = console.warn;
  const originalConsoleTrace = console.trace;

  console.error = (...args) => {
    if (!isToCollector) {
      sendConsoleDataToCollector(4, 'Error', args.toString());
    }
    return originalConsoleError.apply(this, args);
  };
  console.warn = (...args) => {
    if (!isToCollector) {
      sendConsoleDataToCollector(3, 'Warning', args.toString());
    }
    return originalConsoleWarn.apply(this, args);
  };
  console.log = (...args) => {
    if (!isToCollector) {
      sendConsoleDataToCollector(1, 'Debug', args.toString());
    }
    return originalConsoleLog.apply(this, args);
  };
  console.trace = (...args) => {
    if (!isToCollector) {
      sendConsoleDataToCollector(0, 'Trace', args.toString());
    }
    return originalConsoleTrace.apply(this, args);
  };
};

// Catches error events in the window and sends the errors to the collector
const eventErrorCatcher = () => {
  window.onerror = (
    _errormessage,
    _errorsource,
    _errorLineNumber,
    _errorColumNumber,
    _error,
  ) => {
    if (_error instanceof Error) {
      if (!isToCollector) {
        sendErrorDataToCollector(
          _error,
          _errormessage,
          _errorsource,
          _errorLineNumber,
          _errorColumNumber,
        );
      }
    }
  };
  window.onunhandledrejection = (_error) => {
    if (IgnoreUnhandledRejectionFromCollector) {
      IgnoreUnhandledRejectionFromCollector = false;
      return;
    }
    _error.promise.catch((_err) => {
      sendErrorDataToCollector(_err);
    });

    window.onmessageerror = (_event) => console.log(_event.source);
  };
};

// overrides the .catch function so that it sends the errors to the collector
const promiseCatchOverride = () => {
  ((Promise) => {
    const originalCatch = Promise.prototype.catch;
    Promise.prototype.catch = function newCatch(...args) {
      IgnoreUnhandledRejectionFromCollector = false;
        sendErrorDataToCollector(args);
      return originalCatch.apply(this, args);
    };
  })(Promise);
};

// overrides the xmlHttpRequest so it sends error status codes to the collector
const xmlHttpRequestOverride = () => {
  (function(send) {
    XMLHttpRequest.prototype.send = function () {
      var callback = this.onreadystatechange
      this.onreadystatechange = function() {
        if (this.readyState == 4) {
          if(!isToCollector && this.status == 0 ){
            sendErrorDataToCollector(Error(`XHR Rejected no status code / Response Url given`));
          }else if (this.status >= 200 && this.status <= 300) console.info('success');
          else sendErrorDataToCollector(Error(`Xml Request failed, Status code: ${this.status}, Url: ${this.responseURL}`));
        }
        if (callback) {
          callback.apply(this, arguments)
        }
      }
      send.apply(this, arguments)
    }
  })(XMLHttpRequest.prototype.send)
};

// overrides the fetch function so it sends error status codes to the collector
const fetchOverride = () => {
  const global = window;
  const { fetch } = global;
  global.fetch = function NewFetch(
    _input,
    _init,
  ) {
    IgnoreUnhandledRejectionFromCollector = false;
    if (!isToCollector) {
      const resolve = fetch.apply(global, [_input, _init]);
      resolve.then((Response) => {
        if(Response.status == 0){
          sendErrorDataToCollector(new Error("Fetch Rejected no status code was given "));
        } else if (!(Response.status < 200) && !(Response.status > 300)) return;
        sendErrorDataToCollector(new Error(Response.statusText));
      });
      return Promise.resolve(resolve);
    }
    const resolve = fetch.apply(global, [_input, _init]);
    let Responses;
    if (!(resolve.status > 200) && !(resolve.status < 300))
      IgnoreUnhandledRejectionFromCollector = true;
    Responses = 'Success';
    return Promise.resolve(Responses);
  };
};

// sets up the Error Collector
(function (window) {
  promiseCatchOverride();
  eventErrorCatcher();
  consoleMessageOverride();
  xmlHttpRequestOverride();
  fetchOverride();

  window.Monitor = {};
  window.Monitor.SendError = sendPost;

  // used to create the setup
  window.Monitor.Setup = function (key, value) {
    if (key) {
      switch (key) {
        // case 'SetApiKey':
        //   settings.ApiKey = value;
        //   break;
        case 'SetLanguage':
          settings.Language = value;
          break;
        default:
          console.info(`${key} is not a valid option`);
          break;
      }
    }
  };
}(window));
