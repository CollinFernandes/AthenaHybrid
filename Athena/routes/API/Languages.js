const express = require('express')
const app = express();
const fs = require('fs')
const path = require('path')

app.get("/api/v1/languages", async (req, res) => {
    res.json(JSON.parse(fs.readFileSync(path.join(config.dir, '/trash/languages.json'))))
})

module.exports = app;