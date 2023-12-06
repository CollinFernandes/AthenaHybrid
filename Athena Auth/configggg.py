import os
bot ={
  "client id": "1133123472713842768",
  "client secret":  os.getenv("csecret"),
  "token": os.getenv("token"),
  "auth_url": "https://discord.com/oauth2/authorize?client_id=1133123472713842768&redirect_uri=https://discord.api.atomicfn.dev/callback&response_type=code&scope=identify+guilds.join"
}
server={
  "id": "1158389486233845792"
}