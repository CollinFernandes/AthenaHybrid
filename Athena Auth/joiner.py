import requests, time, base64, json
import config

def add_to_guild(access_token, user_id, hehe, ip):
    try:
        dataaa = refresh_token(access_token)
        access_token = dataaa.get("access_token", hehe)
        if access_token != hehe:
            niw = open("access_tokens.json")
            rjson = json.load(niw)
            rjson[ip]['randomshit'] = dataaa["refresh_token"]
            rjson[ip]['refreshtoken'] = access_token
            open('access_tokens.json','w').write(json.dumps(rjson, indent=4))
            print(f"Refreshed Data {user_id}")
        print('Access token:'+access_token)
        url = f"https://discord.com/api/v10/guilds/{config.server['id']}/members/{user_id}"
        data = {
            "access_token" : access_token,
        }
        headers = {
            "Authorization" : "Bot "+config.bot['token'],
            'Content-Type': 'application/json'
        }
        response = requests.put(url=url, headers=headers, json=data, timeout=20)
        
        print(response.text)
        try:
            if response.json().get("retry_after") or response.status_code == 429:
             print("Sleep to " + response.json().get('retry_after',5) + " seconds on " + user_id + "!");
             time.sleep(response.json().get("retry_after",5)+3)
             add_to_guild(access_token=access_token, user_id=user_id, hehe=hehe, ip=ip)
            else:
             print('Success To '+user_id)
            try:
             response.raise_for_status()
             print('Success Code 200 to '+user_id)
            except:
             print(str('Failire To '+user_id+' by '+response.status_code))
          
        except:
            print(f'Reponse By {user_id} : {response.text}')
            pass
    except:
        pass
    time.sleep(5)
def add_all():
 for k,v in json.load(open("access_tokens.json")).items():
    access_token = v["randomshit"]
    user_id = v["id"]
    print(access_token, user_id)
    add_to_guild(access_token,user_id, v["refreshtoken"], k)
    refresh_data(k)

def refresh_token(refresh_token):
  data = {
    'client_id': config.bot['client id'],
    'client_secret': config.bot['client secret'],
    'grant_type': 'refresh_token',
    'refresh_token': refresh_token
  }
  headers = {
    'Content-Type': 'application/x-www-form-urlencoded'
  }
  r = requests.post('%s/oauth2/token' % 'https://discord.com/api/v10', data=data, headers=headers)
  print(r.text, r.status_code)
  if r.status_code == 429: 
    print("Sleep")
    time.sleep(r.json()["retry_after"]+3)
    refresh_token(refresh_token)
  if "access_token" not in r.text:
    return {}
  #r.raise_for_status()
  return r.json()
def refresh_data(ip):
 try:
  with open("access_tokens.json", "r") as f:
    data = json.load(f)
  dataa = refresh_token(data[ip]["randomshit"])
  data[ip]["randomshit"] = dataa["refresh_token"]
  data[ip]["refreshtoken"] = dataa["access_token"]
  with open("access_tokens.json", "w") as f:
    json.dump(data, f, indent=4)
 except: pass 
  
if __name__ == "__main__":
  add_all()