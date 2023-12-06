const express = require('express')
const app = express();
const fs = require('fs')
const config = require('../../config')
const path = require('path')

app.get('/api/v1/customBackgrounds', async (req, res) => {
    res.json(JSON.parse(fs.readFileSync(path.join(config.dir, '/trash/customBackgroundList.json'))))
});

app.get('/api/v1/officialBackgrounds', async (req, res) => {
    res.json(JSON.parse(fs.readFileSync(path.join(config.dir, '/trash/backgrounds.json'))))
});

module.exports = app;