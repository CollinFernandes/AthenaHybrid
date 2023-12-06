const config = require('../config')

function sendSuccessLog(message) {
    console.log(`\x1b[90m[\x1b[36m${config.name}\x1b[90m | \x1b[92mSUCCESS\x1b[90m] → \x1b[90m${message}`)
}

function sendReqLog(message) {
    console.log(`\x1b[90m[\x1b[36m${config.name}\x1b[90m | \x1b[92mREQUEST\x1b[90m] → \x1b[90m${message}`)
}

function sendWarningLog(message) {
    console.log(`\x1b[90m[\x1b[36m${config.name}\x1b[90m | \x1b[33mWARNING\x1b[90m] → \x1b[33m${message}`)
}

function sendErrorLog(message) {
    console.log(`\x1b[90m[\x1b[36m${config.name}\x1b[90m | \x1b[31mERROR\x1b[90m] → \x1b[90m${message}`)
}

module.exports = { sendSuccessLog, sendWarningLog, sendErrorLog, sendReqLog };