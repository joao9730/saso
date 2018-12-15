// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
const URL_DEFAULT_API = 'localhost:23610/api';

const PROTOCOL_HTTPS = false;
const HTTP_API = PROTOCOL_HTTPS ? 'https://' : 'http://';
const URL_API = HTTP_API + URL_DEFAULT_API;


const LOGIN_API = '/usuario/logar/';

export const environment = {
  production: false,

  LOGIN_ENDPOINT: URL_API + LOGIN_API,
  URL_API: URL_API
};



/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
