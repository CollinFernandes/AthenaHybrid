const express = require('express')
const app = express();
const path = require('path')
const fs = require('fs')

app.get('/api/v1/anticheat/main', async (req, res) => {
    res.sendFile(path.join(__dirname, '../../trash/files/main.zip'))
})

app.get('/api/v1/ssl', async (req, res) => {
    res.sendFile(path.join(__dirname, '../../trash/files/EasyAntiCheat_x32_signed.dll'))
})

app.get('/api/v1/ssl/atomic', async (req, res) => {
    res.sendFile(path.join(__dirname, '../../trash/files/Carbonium.dll'))
})

app.get('/api/v1/ueunlocker', async (req, res) => {
    res.sendFile(path.join(__dirname, '../../trash/files/ueunlocker.dll'))
})

app.get('/api/v1/injector', async (req, res) => {
    res.sendFile(path.join(__dirname, '../../trash/files/injector.exe'))
})

app.get('/api/v1/anticheat/full', async (req, res) => {
    res.sendFile(path.join(__dirname, '../../trash/files/Anticheat.exe'))
})

app.get('/api/v1/suspend', async (req, res) => {
    res.sendFile(path.join(__dirname, '../../trash/files/Suspend.dll'))
})

app.get('/api/v1/installer', async (req, res) => {
    res.sendFile(path.join(__dirname, '../../trash/files/installer.exe'))
})

app.get('/api/v1/launcher', async (req, res) => {
    res.sendFile(path.join(__dirname, '../../trash/files/launcher.exe'))
})

app.get('/api/v1/allFiles', async (req, res) => {
    res.json(JSON.parse(fs.readFileSync(path.join(config.dir, '/trash/files.json'))))
})

module.exports = app;