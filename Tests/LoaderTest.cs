using System.Data.SqlTypes;
using System.IO;
using System.IO.IsolatedStorage;
using ModelLoader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLoader.HMF;
using ModelLoader.I2N;
using ModelLoader.SMF;
using ModelLoader.TMF;
using ModelLoader.SAF;
using System;
using ModelLoader.MTF;

namespace Tests
{
    
    
    /// <summary>
    ///This is a test class for LoaderTest and is intended
    ///to contain all LoaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LoaderTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

		private const string Directory = @"D:\Programowanie\habanero\work\Content\meshes\";

        /// <summary>
        ///A test for GetSMF
        ///</summary>
        [TestMethod()]
        public void GetSMFTest()
        {
			const string path = Directory + @"Dragon\dragon.smf";
            SMF expected = null;
            SMF actual;
            actual = Loader.GetSMF(path);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetTMF
        ///</summary>
        [TestMethod()]
        public void GetTMFTest()
        {
			const string path = Directory + @"Dragon\dragon.tmf";
            TMF expected = null;
            TMF actual;
            actual = Loader.GetTMF(path);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetSAF
        ///</summary>
        [TestMethod()]
        public void GetSAFTest()
        {
            const string path = Directory + @"Dragon\dragon.saf";
            SAF expected = null;
            SAF actual;
            actual = Loader.GetSAF(path);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetMTF
        ///</summary>
        [TestMethod()]
        public void GetMTFTest()
        {
			const string path = Directory + @"HM1\grass.mtf";
            MTF expected = null;
            MTF actual;
            actual = Loader.GetMTF(path);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

		/// <summary>
		///A test for GetMTF
		///</summary>
		[TestMethod()]
		public void WriteMTFTest()
		{
			const string path = Directory + @"HM1\grass.mtf";
			MTF expected = null;
			var actual = Loader.GetMTF(path);
			actual.UseTexNormal = false;
			actual.TexDiffuse = 1;
			using (var stream = new FileStream(path, FileMode.OpenOrCreate))
			{
				using (var writer = new BinaryWriter(stream))
				{
					actual.Write(writer);
				}
			}
			//Assert.AreEqual(expected, actual);
			//Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Write HMF
		///</summary>
		[TestMethod()]
		public void WriteHMFTest()
		{
			const string hmDirectory = Directory + @"HM1";
			const string path = hmDirectory + @"\HM.hmf";
			if (!System.IO.Directory.Exists(hmDirectory))
				System.IO.Directory.CreateDirectory(hmDirectory);
			var actual = new HMF(new HeightMap(1, 2, 0.05F, 128, 128, 40, 40));
			using (var stream = new FileStream(path, FileMode.OpenOrCreate))
			{
				using (var writer = new BinaryWriter(stream))
				{
					actual.Write(writer);
				}
			}
		}

		/// <summary>
		///A test for GetMTF
		///</summary>
		[TestMethod()]
		public void GetI2NTest()
		{
			const string path = Directory + @"Dragon\i2n";
			const string path2 = Directory + @"Dragon\i2n2";
			I2N expected = null;
			I2N actual;
			actual = Loader.GetI2N(path);
			using (var stream = new FileStream(path2, FileMode.OpenOrCreate))
			{
				using (var writer = new StreamWriter(stream))
				{
					actual.Write(writer);
				}
			}
			//Assert.AreEqual(expected, actual);
			//Assert.Inconclusive("Verify the correctness of this test method.");
		}
    }
}
