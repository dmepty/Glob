# Library for WildCard

Use IsMatch() method

`GlobPattern globPattern = new GlobPattern();` <br>
`string str = "test";`<br>
`string pattern = "?[d-f]*"`<br>
`var result = globPattern.IsMatch(str, pattern); //true`
***
Use FindList() method

`List<string> list = new List<string>`<br>
`{`<br>
`     "admin.panel.org",`<br>
`     "account.domain.tld",`<br>
`     "admin.google.com",`<br>
`    "admin.site.ru",`<br>
`    "info.test.com",`<br>
`};`<br><br>
`GlobPattern globPattern = new GlobPattern();` <br>
`string pattern = "*.com"`<br>
`globPattern.FindList(list, pattern); // admin.google.com, info.test.com`
