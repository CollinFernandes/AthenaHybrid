#pragma once
#include "defs.h"
#include "build.h"
#include <string>
#include <iostream>
#include "util.h"
uintptr_t CurlEasyOptP = sigscan(ENC("89 54 24 10 4C 89 44 24 18 4C 89 4C 24 20 48 83 EC 28 48 85 C9"));
uintptr_t CurlSetOptP = sigscan(ENC("48 89 5C 24 08 48 89 6C 24 10 48 89 74 24 18 57 48 83 EC 30 33 ED 49 8B F0 48 8B D9"));

typedef void CURL;

// original easyopt thing we will use to setuo curl and do normal execution
auto (*_curl_easy_setopt)(CURL* cURL, uintptr_t option, ...)->CURLcode;

auto changeeasyopt(CURL* Curl, uintptr_t opt, va_list info)->CURLcode
{
    int OFF = 0;
    switch (opt)
    {
    case CURLOPT_NOPROXY:
        return _curl_easy_setopt(Curl, opt, ProxyHost);
        break;

    case CURLOPT_SSL_VERIFYPEER:
        return _curl_easy_setopt(Curl, opt, OFF);
        break;
    case CURLOPT_SSL_VERIFYHOST:
        return _curl_easy_setopt(Curl, opt, OFF);
        break;
    case CURLOPT_PINNEDPUBLICKEY:
        return CURLcode::CURLE_OK;
        break;
    case CURLOPT_URL:
        std::string url = info;
        std::regex Host(ENC("https:\\/\\/(.*)\\.ol\\.epicgames.com"));
        std::regex eosHost(ENC("api.epicgames.dev"));
        if (bIsHybrid)
        {
            Log(("LogURL: " + url).c_str());
            if (std::regex_search(info, std::regex(ENC("/fortnite/api/cloudstorage/system")))) {
                url = std::regex_replace(info, Host, host);
            }
            else if (std::regex_search(info, std::regex(ENC("/fortnite/api/game/v2/profile")))) {
                url = std::regex_replace(info, Host, host);
            }
            else if (std::regex_search(info, std::regex(ENC("/content/api/pages/fortnite-game")))) {
                url = std::regex_replace(info, Host, host);
            }
            else if (std::regex_search(info, std::regex(ENC("/fortnite/api/storefront/v2/catalog")))) {
                url = std::regex_replace(info, Host, host);
            }
            else if (std::regex_search(info, std::regex(ENC("/api/v1/fortnite-br/surfaces/eco-motd/target")))) {
                url = std::regex_replace(info, std::regex(ENC("https:\\/\\/(.*)\\.on\\.epicgames.com")), host);
            }
            else if (std::regex_search(info, std::regex(ENC("/api/v1/fortnite-br/surfaces/br-motd/target")))) {
                url = std::regex_replace(info, std::regex(ENC("https:\\/\\/(.*)\\.on\\.epicgames.com")), host);
            }
            else if (std::regex_search(info, std::regex(ENC("/api/v1/games/fortnite/trackprogress")))) {
                url = std::regex_replace(info, Host, host);
            }
            else if (std::regex_search(info, std::regex(ENC("/datarouter/api/v1/public/data")))) {
                url = std::regex_replace(info, Host, host);
            }
            else if (std::regex_search(info, std::regex(ENC("/fortnite/api/matchmaking/session/.*join")))) {
                Log("Bypassed Ban!");
                url = std::regex_replace(info, Host, "atomicfn.site");
            }
            else if (std::regex_search(info, std::regex(ENC("/waitingroom/api/waitingroom")))) {
                Log("Bypassed Queue!");
                url = std::regex_replace(info, Host, "atomicfn.site");
            }
            return _curl_easy_setopt(Curl, opt, url.c_str());
            break;
        }
#ifdef READFILE
        std::cin.getline(MyReadFile, myText);
        Backend = myText;
        std::cin.getline(MyReadFile, hybridyesorno);
        if (hybridyesorno == ENC("private"))
        {
            bIsHybrid = false;
        }
        else bIsHybrid;
        MyReadFile.close();
#endif
        else
        {
            if (std::regex_search(info, Host)) {
                url = std::regex_replace(info, Host, host);
                return _curl_easy_setopt(Curl, opt, url.c_str());
                break;
            }
        }
    }

    return _curl_easy_setopt(Curl, opt, info);
}

/*

If for some reason your messing with this, here are some bugs I fixed:

1. Game would crash after like 5 seconds. This means you forgot to continue normal execution
2. Wouldn't redirect, but it was comign up in logs. No idea how to fix, just mess around with it.
Fix for 2: Make host not encrypted

*/