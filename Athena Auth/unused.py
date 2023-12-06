query = {
  "client_id":str(botid),
  "response_type":"code",
  "redirect_uri":"https://restorecord.com/api/callback",
  "scope":"identify guilds.join",
  "state":str(serverid)
}
request = requests.post(f"https://discord.com/api/v9/oauth2/authorize", headers=bypassheaders(tokenn), params=query, json={"permissions":"0","authorize":True})
if request.status_code == 200:
if "location" in request.text:
localbypass = requests.get(request.json()["location"], headers=bypassheaders(tokenn), allow_redirects=True)
if localbypass.status_code in [200, 307, 403]:
  Logging.success(f"Successfully Bypassed {tokenn[:19]} RestoreCord")
  tkns = requests.get("https://discord.com/api/v9/oauth2/tokens", headers=bypassheaders(tokenn))
  for i in tkns.json():
     if i["application"]["id"] == str(botid):
       r = requests.delete("https://discord.com/api/v9/oauth2/tokens/" + i["id"], headers=bypassheaders(tokenn))
       if r.status_code == 204:
          Logging.success(f"Successfully Deauthed {tokenn[:19]} RestoreCord")
       elif r.status_code == 401:
          Logging.failure(f"Invalid token {tokenn[:19]} [RIP]")
       elif r.status_code == 429:
          Logging.rate_limit(f"Ratelimited on {tokenn[:19]} [RIP]"); 	
       else:
          Logging.failure(f"Failed to Deauth {tokenn[:19]} RestoreCord [RIP] // {r.status_code}")