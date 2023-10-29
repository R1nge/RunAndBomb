using UnityEngine;

public static class NameGenerator
{
    public static string GenerateName()
    {
        string[] name1 = { "gh", "br", "c", "cr", "dr", "g", "gr", "kr", "k", "kh", "n", "q", "qh", "sc", "scr", "str", "st", "t",
            "tr", "thr", "v", "vr", "x", "z", "", "", "", "", "" };
        string[] name2 = { "a", "e", "ae", "ao", "ai", "au", "uo", "a", "e", "i", "o", "u", "i", "o", "u", "a", "e", "i", "o", "u",
            "a", "e", "i", "o", "u", "a", "e", "i", "o", "u", "a", "e", "i", "o", "u" };
        string[] name3 = { "cr", "cz", "dr", "gr", "c", "k", "n", "q", "t", "v", "x", "z", "c", "cc", "gn", "gm", "gv", "gz", "k",
            "kk", "kn", "kr", "kt", "kv", "kz", "lg", "lk", "lq", "lx", "lz", "nc", "ndr", "nkr", "ngr", "nk", "nq", "nqr", "nz", "q", "qr",
            "qn", "rc", "rg", "rk", "rkr", "rq", "rqr", "sc", "sq", "str", "t", "v", "vr", "x", "z", "q", "k", "rr", "r", "t", "tt", "vv",
            "v", "x", "z", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        string[] name4 = { "a", "e", "i", "", "a", "e", "i", "o", "u", "o", "u", "a", "e", "i", "o", "u", "oi", "ie", "ai", "ei", "eo", "ui" };
        string[] name5 = { "ks", "l", "ls", "n", "d", "ds", "k", "ns", "ts", "x" };
        int r1 = Random.Range(0, name1.Length);
        int r2 = Random.Range(0, name2.Length);
        int r3 = Random.Range(0, name3.Length);
        int r4 = Random.Range(0, name4.Length);
        int r5 = Random.Range(0, name5.Length);
        while (name3[r3] == name1[r1] || name3[r3] == name5[r5]) r3 = Random.Range(0, name3.Length);
        if (name3[r3] == string.Empty) r4 = 0;
        else while (name4[r4] == string.Empty) r4 = Random.Range(0, name4.Length);
        string name = name1[r1] + name2[r2] + name3[r3] + name4[r4] + name5[r5];
        return name;
    }
}