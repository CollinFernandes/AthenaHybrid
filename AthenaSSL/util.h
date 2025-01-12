#pragma once
#include <Windows.h>
#include <vector>
#include <string>
#include <iostream>

// pattern scanning from soemone not me idk who.

#define in_range(x, a, b) (x >= a && x <= b)
#define get_bits(x) (in_range((x & (~0x20)), 'A', 'F') ? ((x & (~0x20)) - 'A' + 0xA): (in_range(x, '0', '9') ? x - '0': 0))
#define get_byte(x) (get_bits(x[0]) << 4 | get_bits(x[1]))

uintptr_t sigscan(std::string pattern, int times = 0)
{
    uintptr_t moduleAdress = (uintptr_t)GetModuleHandleA(0);

    static auto patternToByte = [](const char* pattern)
    {
        auto       bytes = std::vector<int>{};
        const auto start = const_cast<char*>(pattern);
        const auto end = const_cast<char*>(pattern) + strlen(pattern);

        for (auto current = start; current < end; ++current)
        {
            if (*current == '?')
            {
                ++current;
                if (*current == '?')
                    ++current;
                bytes.push_back(-1);
            }
            else { bytes.push_back(strtoul(current, &current, 16)); }
        }
        return bytes;
    };

    const auto dosHeader = (PIMAGE_DOS_HEADER)moduleAdress;
    const auto ntHeaders = (PIMAGE_NT_HEADERS)((std::uint8_t*)moduleAdress + dosHeader->e_lfanew);

    const auto sizeOfImage = ntHeaders->OptionalHeader.SizeOfImage;
    auto       patternBytes = patternToByte(pattern.c_str());
    const auto scanBytes = reinterpret_cast<std::uint8_t*>(moduleAdress);

    const auto s = patternBytes.size();
    const auto d = patternBytes.data();

    size_t nFoundResults = 0;

    for (auto i = 0ul; i < sizeOfImage - s; ++i)
    {
        bool found = true;
        for (auto j = 0ul; j < s; ++j)
        {
            if (scanBytes[i + j] != d[j] && d[j] != -1)
            {
                found = false;
                break;
            }
        }
        if (found)
        {
            if (times != 0)
            {
                if (nFoundResults < times)
                {
                    nFoundResults++;                                   // Skip Result To Get nSelectResultIndex.
                    found = false;                                     // Make sure we can loop again.
                }
                else
                {
                    return reinterpret_cast<uintptr_t>(&scanBytes[i]);  // Result By Index.
                }
            }
            else
            {
                return reinterpret_cast<uintptr_t>(&scanBytes[i]);      // Default/First Result.
            }
        }
    }
    return NULL;
}

void nl()
{
    std::cout << std::endl;
}

void Log(const char* msg, bool newline = true)
{
    //log to AlowConsole
    std::cout << msg;
    if (newline)
        nl();

}

void DebugLog(const char* msg, bool newline = true)
{
#ifdef _DEBUG
    Log(msg, newline);
#endif
}

const char* charcmb(const char* msg1, const char* msg2)
{
    static char msg[256];
    sprintf_s(msg, "%s%s", msg1, msg2);
    return msg;
}

bool checkSig(uintptr_t& sig, const char* sigmsg)
{
    if (sig == NULL)
    {
        Log(charcmb("Failed to find signature: ", sigmsg));
        return false;
    }
    return true;
}

void exit(const char* exitMsg)
{
    Log(exitMsg);
    exit(0);
}

void test()
{
    Log("test");
}