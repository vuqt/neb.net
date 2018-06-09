# neb.net

neb.net is the Nebulas compatible C# API. 
Users can sign/send transactions and deploy/call smart contract with it.

## Requirements
neb.net requires the following:

- .NET Framework v4.5.2
- Newtonsoft.Json v11.0.2
- RestSharp v106.3.0

## Installation
Make sure you have installed Newtonsoft.Json and RestSharp:
![Libraries](/media/help-1.png)

Add [NebulasAPI.dll](/build/latest) to your project

## Usage

Please refer to [test project](/src/NebulasAPI.Tests) to learn how to use neb.php.

GetNebState:
```
public NebState GetNebState()
```

GetAccountState:
```
public AccountState GetAccountState(string address, Int64 height = 0)
```

## Join in!

I am happy to receive bug reports, fixes, documentation enhancements, and other improvements.




