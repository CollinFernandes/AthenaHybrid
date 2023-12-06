const express = require('express');
const app = express();
const fs = require('fs');

app.get("/:videoid/master.blurl", (req, res) => {
  if (fs.existsSync(`${__dirname}/trash/blurl/${req.params.videoid}/master.blurl`)) {
    res.setHeader("content-type", "application/octet-stream")
    res.sendFile(`${__dirname}/trash/blurl/${req.params.videoid}/master.blurl`)
  }
})

module.exports = app;