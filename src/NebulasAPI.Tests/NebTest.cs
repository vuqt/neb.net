using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NebulasAPI.Models;

namespace NebulasAPI.Tests
{
    [TestClass]
    public class NebTest
    {
        private const string TESTNET_ACCOUNT = "n1YhBEZsqKgCrH7gNyH5ntqe1sdwcJfn1aB";
        private const string TESTNET_PASSPHRASE = "919d037ae30920d81bd22dc0faa6755e9101e27cf7599f4ca11b67580ed32229";

        private const string TESTNET_ACCOUNT1 = "n1Faudpa5KELDTHta72BkVm66N5DYT6XEtA";
        private const string TESTNET_PASSPHRASE1 = "7ebd64416ceb1fc6dbca228b58383aa908a0b15e44743ce6e828d10d7ab049a3";

        private const string TEST_HASH = "42df39e2d6c1aa030f3d6534c1569f3dd2e01f8e7328f0f07981ecf9d2e412ca";
        private const string TEST_TXHASH = "49ecaf78cde972cf51c8f27f99d8298705a8be3cd2fcfba02cde658580c31449";
        private const string TEST_CONTRACT_ADDRESS = "n1ejHTW53PwN6APAY7a58J2EHAZFJTQNayv";

        private int nonce = 1;

        [TestMethod]
        public void TestGetNebState()
        {
            Neb neb = new Neb();

            var result = neb.GetNebState();

            Assert.IsTrue(result.message == string.Empty);
        }

        [TestMethod]
        public void TestGetAccountState()
        {
            Neb neb = new Neb();

            string strAddress = "n1Z6SbjLuAEXfhX1UJvXT6BB5osWYxVg3F3";
            var result = neb.GetAccountState(strAddress);

            Assert.IsTrue(result.message == string.Empty);
        }

        [TestMethod]
        public void TestGetLatestIrreversibleBlock()
        {
            Neb neb = new Neb();

            var result = neb.LatestIrreversibleBlock();

            Assert.IsTrue(result.message == string.Empty);
        }

        /*[TestMethod]
        public void TestSignTransactionWithPassphrase()
        {
            Neb neb = new Neb();

            TransactionData transaction = GenerateTransaction();
            string passphrase = TESTNET_PASSPHRASE;

            SendTransactionWithPassphrase result = neb.SendTransactionWithPassphrase(transaction, passphrase);

            Assert.IsTrue(result.message == string.Empty);
        }*/

        [TestMethod]
        public void TestGetBlockByHash()
        {
            Neb neb = new Neb();

            var result = neb.GetBlockByHash(TEST_HASH, true);

            Assert.IsTrue(result.message == string.Empty);
        }

        [TestMethod]
        public void TestGetBlockByHeight()
        {
            Neb neb = new Neb();

            var result = neb.GetBlockByHeight(415520, true);

            Assert.IsTrue(result.message == string.Empty);
        }

        [TestMethod]
        public void TestGetTransactionReceipt()
        {
            Neb neb = new Neb();

            var result = neb.GetTransactionReceipt(TEST_TXHASH);

            Assert.IsTrue(result.message == string.Empty);
        }

        [TestMethod]
        public void TestGetTransactionByContract()
        {
            Neb neb = new Neb();

            var result = neb.GetTransactionByContract(TEST_CONTRACT_ADDRESS);

            Assert.IsTrue(result.message == string.Empty);
        }

        [TestMethod]
        public void TestGetGasPrice()
        {
            Neb neb = new Neb();

            var result = neb.GetGasPrice();

            Assert.IsTrue(result.message == string.Empty);
        }

        [TestMethod]
        public void TestEstimateGas()
        {
            Neb neb = new Neb(true);

            var result = neb.EstimateGas(TESTNET_ACCOUNT, TESTNET_ACCOUNT1, "10000000000000", 1000, "1000000", "2000000");

            Assert.IsTrue(result.message == string.Empty);
        }

        [TestMethod]
        public void TestGetEventsByHash()
        {
            Neb neb = new Neb();

            var result = neb.GetEventsByHash(TEST_TXHASH);

            Assert.IsTrue(result.message == string.Empty);
        }

        /*[TestMethod]
        public void TestSubscribe()
        {
            Neb neb = new Neb();

            string[] topics = { "chain.linkBlock", "chain.latestIrreversibleBlock" };
            var result = neb.Subscribe(topics);

            Assert.IsTrue(result.message == string.Empty);
        }*/

        [TestMethod]
        public void TestGetDynasty()
        {
            Neb neb = new Neb();

            var result = neb.GetDynasty(1);

            Assert.IsTrue(result.message == string.Empty);
        }

        [TestMethod]
        public void TestSimulateCall()
        {
            //http://inty.co#u2355c
            Neb neb = new Neb();

            ContractInfo contractInfo = new ContractInfo();
            contractInfo.function = "get";
            contractInfo.args = "[\"u2355c\"]";
            var result = neb.SimulateCall(TEST_CONTRACT_ADDRESS, contractInfo);

            Assert.IsTrue(result.message == string.Empty);
        }
    }
}
