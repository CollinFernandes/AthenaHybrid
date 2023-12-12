#pragma once

#include "strencrypt.hpp"
const char* ProxyHost = ENC("");

#define PROD
//#define SENDLOGSTOCONSOLE
#define WRITELOGSTOFILE
//#define READFILE

//add a devname variable to the dll
//const char* Backend = "35.172.230.220:6969";
const char* host = "frostchanger.de:3012";
const char* eos = "Backend-1.raxterxpsycho.repl.co";
constexpr bool INGAME = true;

#ifdef READFILE // man that 1kb is important ok :/
std::string myText;
std::string hybridyesorno;
std::ifstream MyReadFile("info.txt");
#endif

#ifndef READFILE
constexpr bool bIsHybrid = true;
#endif
#ifdef READFILE
bool bIsHybrid;
#endif
