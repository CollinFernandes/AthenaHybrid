const express = require('express')
const app = express();

app.all('/datarouter/api/v1/public/data', async (req, res) => {
    res.status(204).send();
})

module.exports = app;