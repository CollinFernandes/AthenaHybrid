const express = require('express')
const fs = require('fs');
const path = require('path');
const app = express();
const crypto = require('crypto')
const cloudStorageTrash = path.join(__dirname, '../../trash/cloudstorage')

app.get('/fortnite/api/cloudstorage/system', async (req, res) => {
    res.json([{
        "uniqueFilename": "DefaultGame.ini",
        "filename": "DefaultGame.ini",
        "hash": "d7cdf93dad8067b549a55a70751d9a43354fad79",
        "hash256": "e85f2af132b7e4a718d3390e02794168d80ded2e2bd2016a5ab02a6dbff50fdc",
        "length": 101893,
        "contentType": "text/plain",
        "uploaded": "2023-01-14T10:23:22.292Z",
        "storageType": "S3",
        "doNotCache": true
    }, {
        "uniqueFilename": "DefaultEngine.ini",
        "filename": "DefaultEngine.ini",
        "hash": "d5246f0ad442800d39d7648d9be7fa2a91dc5b97",
        "hash256": "44f339e4469b603fd34548b410d99cb6115cbe859f81d4550f16a4a37d2b8cbf",
        "length": 1283,
        "contentType": "text/plain",
        "uploaded": "2023-01-14T10:23:31.432Z",
        "storageType": "S3",
        "doNotCache": true
    }, {
        "uniqueFilename": "DefaultRuntimeOptions.ini",
        "filename": "DefaultRuntimeOptions.ini",
        "hash": "15a74ed65d15decb5abea9e24c695e5c04edb2db",
        "hash256": "d9282432d979d6592767b320fc482162b4f738b9ee9e42d98adceb1b6306fa43",
        "length": 1013,
        "contentType": "text/plain",
        "uploaded": "2023-01-14T10:23:43.070Z",
        "storageType": "S3",
        "doNotCache": true
    }])
})

app.get('/fortnite/api/cloudstorage/system/:fileName', async (req, res) => {
    const fileName = req.params.fileName
    const filePath = cloudStorageTrash + "/" + fileName
    if(fs.existsSync(filePath)) {
        res.send(filePath)
        return;
    } else {
        res.status(404).end();
        return;
    }
})

module.exports = app;