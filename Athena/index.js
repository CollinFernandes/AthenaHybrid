const express = require("express");
const { updateAthena } = require("./utils/updateAthena");
var figlet = require("figlet");
const fs = require('fs')
var bodyParser = require('body-parser')

class mainEntrance {
  get directory() {
    return `${__dirname}`;
  }

  constructor() {
    this.config = require(`${this.directory}/config`);
    this.logs = require(`${this.directory}/utils/logs`);
    this.app = express();
  }

  registerRouts() {
    this.app.set('view engine', 'ejs')
    this.app.use((req, res, next) => {
        if (!req.url.includes('.')) {
            if (!req.url.split('/').pop() == '') {
                this.logs.sendReqLog(`${req.url}`);
            }
        }
      next();
    });

    fs.readdirSync(`${this.directory}/routes/Fortnite`).forEach(route => {
        this.app.use(require(`${this.directory}/routes/Fortnite/${route.split('.')[0]}`))
        this.logs.sendSuccessLog(`Successfully registered the Fortnite API Route: ${route.split('.')[0]}.`)
    })

    fs.readdirSync(`${this.directory}/routes/API`).forEach(route => {
      this.app.use(require(`${this.directory}/routes/API/${route.split('.')[0]}`))
      this.logs.sendSuccessLog(`Successfully registered the API Route: ${route.split('.')[0]}.`)
    })

    fs.readdirSync(`${this.directory}/trash/files/redirects`).forEach(redirect => {
      this.app.get(`/redirects/${redirect.split('.')[0]}`, async (req, res) => {
        const filef = fs.readFileSync(`${this.directory}/trash/files/redirects/${redirect.split('.')[0]}.json`);
        const file = JSON.parse(filef)
        res.redirect(file.url)
      });
    })

    this.app.get('/api/v1/redirects/createRedirect', async (req, res) => {
      const authorization = req.headers["authorization"];
      if (authorization == this.config.authorization) {
      const redirect = req.headers.redirect;
      const url = req.headers.url;
      const redirectData = {
          "url": url
      };
      fs.writeFile(`${this.directory}/trash/files/redirects/${redirect}.json`, JSON.stringify(redirectData, null, 2), function(err) {
        if(err) {
            return console.log(err);
        }
        res.status(200)
      }); 
      this.app.get(`/redirects/${redirect}`)
      this.logs.sendSuccessLog(`Successfully created the Redirect: ${redirect}.`)
      } else {
        res.status(401);
      }
    })

    // this.app.use('/', express.static('web'))
  this.app.use("/cdn", express.static("trash/files/cdn", { etag: false, cacheControl: false }));
  }

  Initialize() {
    this.app.use(bodyParser.urlencoded({ extended: false }))
    this.app.use(bodyParser.json())
    updateAthena();
    setTimeout(() => {
      console.clear();
      console.log("\x1b[36m\n");
      figlet.text(
        "Athena",
        {
          font: "Larry 3D",
          horizontalLayout: "default",
          verticalLayout: "default",
          width: 80,
          whitespaceBreak: true,
        },
        function (err, data) {
          if (err) {
            console.log("Something went wrong...");
            console.dir(err);
            return;
          }
          console.log(data);
        }
      );
      setTimeout(() => {
        this.logs.sendWarningLog('starting registering routes!')
        this.registerRouts()
        this.app.listen(this.config.port, () => {
          this.logs.sendSuccessLog(
            `Successfully started the Backend on Port ${this.config.port}!`
          );
        });
      }, 300);
    }, 4000);
  }
}

backend = new mainEntrance();
backend.Initialize();