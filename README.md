# neb.net

neb.net is the Nebulas compatible C# API. 
Users can sign/send transactions and deploy/call smart contract with it.

## Requirements
neb.net requires the following:

- .NET Framework v4.6.1 or later
- Newtonsoft.Json v11.0.2 or later
- RestSharp v106.3.0 or later

## Installation
Make sure you have installed Newtonsoft.Json and RestSharp lastest version:

![Libraries](/media/help-1.png)

Add [NebulasAPI.dll](/build/latest) to your project

## Usage

Please refer to [test project](/src/NebulasAPI.Tests) to learn how to use neb.php.

Please refer to [https://github.com/nebulasio/wiki/blob/master/rpc.md](https://github.com/nebulasio/wiki/blob/master/rpc.md) for more information about Nebulasio API.

GetNebState:
```
public NebState GetNebState()
```

GetAccountState:
```
public AccountState GetAccountState(string address, Int64 height = 0)
```

LatestIrreversibleBlock
```
public LatestIrreversibleBlock LatestIrreversibleBlock()
```

GetBlockByHash
```
public IrreversibleBlock GetBlockByHash(string hash, bool full_fill_transaction)
```

GetBlockByHeight
```
public IrreversibleBlock GetBlockByHeight(Int64 height, bool full_fill_transaction)
```

GetTransactionReceipt
```
public TransactionReceipt GetTransactionReceipt(string hash)
```

GetTransactionByContract
```
public TransactionReceipt GetTransactionByContract(string address)
```

GetGasPrice
```
public GasPrice GetGasPrice()
```

EstimateGas
```
public EstimateGas EstimateGas(string from, string to, string value, int nonce, string gasPrice, string gasLimit)
```

GetEventsByHash
```
public EventsByHash GetEventsByHash(string hash)
```

Subscribe
```
public Subscribe Subscribe(string[] topics)
```

GetDynasty
```
public Dynasty GetDynasty(Int64 height)
```


## Join in!

I am happy to receive bug reports, fixes, documentation enhancements, and other improvements.

Please report bugs via the [github issue](https://github.com/vuqt/neb.net/issues).



