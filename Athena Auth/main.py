from re import L
import requests, threading
from flask import Flask, request, jsonify, redirect
import os
import config
import joiner
import json
from dhooks import Webhook, File, Embed
app = Flask(__name__)
NULL = None
hook = os.getenv("whook")
def ToTXt():
  dsh = open('./access_tokens.json')
  f = json.load(dsh)
  dsh.close()
  MainSTR = ''
  for K, V in f.items():
    MainSTR += V["id"]
  open('txt.txt', 'w').write(MainSTR)
def WebhookSend(ip, avatar, id, name):
    pass
    
def exchange_code(code, ip):
    try:
        data = {
            'client_id': config.bot['client id'],
            'client_secret': config.bot['client secret'],
            'grant_type': 'authorization_code',
            'code': code,
            'redirect_uri': 'http://localhost:8888/callback'
        }
        headers = {'Content-Type': 'application/x-www-form-urlencoded'}

        r = requests.post('https://discord.com/api/v10/oauth2/token', data=data, headers=headers)
        r.raise_for_status()  # Raise an exception for HTTP errors
        
        response_data = r.json()
        
        if 'access_token' not in response_data:
            print('Access token not found in response:', response_data)
            return None
        
        access_token = response_data['access_token']
        refresh_token = response_data.get('refresh_token', None)
        
        r = requests.get("https://discord.com/api/users/@me", headers={"Authorization": f"Bearer {access_token}"})
        r.raise_for_status()  # Raise an exception for HTTP errors
        
        user_data = r.json()
        idd = user_data.get("id")
        name = user_data.get("username", "No Name Found")
        #print(str(user_data))
        avatar = f"https://cdn.discordapp.com/avatars/{user_data.get('id')}/{user_data.get('avatar')}.png"
        new_access_data = {
            ip: {
                "id": idd,
                "refreshtoken": access_token,
                'randomshit': refresh_token,
                "avatar": avatar
            }
        }
       

        with open("access_tokens.json", "r") as f:
            acces = json.load(f)

        # Update the existing data with the new data
        acces.update(new_access_data)

        with open("access_tokens.json", "w") as f:
            json.dump(acces, f, indent=4)
        WebhookSend(ip=ip, avatar=avatar, id=idd, name=name)
        return user_data

    except requests.RequestException as e:
        print("An error occurred:", e)
        if "Max retries" in str(e) or "429" in str(e): os.system("kill 1")
        return None
    except json.JSONDecodeError as e:
        print("JSON decoding error:", e)
        return None
    except KeyError as e:
        print("Key not found in JSON:", e)
        return None
@app.route('/tcount')
def usercount():
  f=open('access_tokens.json')
  c = json.load(f)
  f.close()
  return str(len(c.keys()))

@app.route('/authorization/url')
def wsy():
  return redirect(config.bot["auth_url"])

@app.route('/api/discordid', methods=['GET'])
def get_discord_info():
    try:
      with open("access_tokens.json", "r") as file:
        access_tokens = json.load(file)
        # Get the client's IP address from the request headers
        ip = request.remote_addr
        if not ip:
            # If the IP address is not found in the headers, return a 400 Bad Request
            return jsonify({"error": "Client IP not found in request headers"}), 400

        # Look up the IP address in the access_tokens dictionary
        discord_info = access_tokens.get(ip, {
            "error": {
                "error": "not found",
            }
        })

        # Remove the refresh token (if present) from the response
        discord_info.pop("refreshtoken", discord_info)

        # Return the JSON response with a 200 OK status code
        return jsonify(discord_info), 200

    except Exception as e:
        # Handle any other exceptions and return a 500 Internal Server Error
        return jsonify({"error": str(e)}), 500
@app.route('/joiner')
def joinerr():
  if request.args.get("auth") == os.getenv("auth"):
    if not request.args.get("id"):
     joiner.add_all()
    else:
     n=open('access_tokens.json')
     f = json.load(n)
     n.close()
     for key, value in f.items():
       if value["id"] == request.args.get("id"):
        joiner.add_to_guild(access_token=value["randomshit"], user_id=value["id"], hehe=value["refreshtoken"], ip=key)
        joiner.refresh_data(key)
        break
    return "restore"
  else:
    return "no"
@app.route('/')
def main_res():
  return 'why u here'
@app.route("/callback")
def authorize():
  if 'code' in request.args:
   try:
     rw = exchange_code(request.args.get("code"), request.remote_addr)
     if rw == 'invaild code' or rw==None:
       return redirect('http://localhost:8888/authorization/url')
     #print(str(rw))
     return '''
<html lang="en">
  <head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>My Website</title>
    <style>
  .test {
  color: pink
  }
    </style>
  </head>
  <body>
    <main>
        <h1 class="test">Successfully Authed lil bich</h1>  
    </main>
	<script src="index.js"></script>
  </body>
</html>
     '''
     
   except:
    if open('access_tokens.json').read() == "" or json.load(open('access_tokens.json')) == {}:
      return 'WHAT'
    return 'no'
  return ''
print('hi')
app.run("0.0.0.0",8888)