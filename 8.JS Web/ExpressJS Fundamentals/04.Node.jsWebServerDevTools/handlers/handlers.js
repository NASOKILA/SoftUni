
const homeHandler = require('./home-handler');
const faviconHandler = require('./favicon-handler');
const staticFileHandler = require('./static-file-handler');

module.exports = [homeHandler, faviconHandler, staticFileHandler];
