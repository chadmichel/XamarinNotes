using System;
using NUnit.Framework;
using ResourceAccess;

namespace ResourceAccessTests
{
    [TestFixture]
    public class NoteAccessorTests 
    {
        ResourceAccessFactory Factory = new ResourceAccessFactory();
        INoteAccessor _noteAccessor;

        public INoteAccessor NoteAccessor
        {
            get
            {
                if (_noteAccessor == null)
                {            
                    _noteAccessor = Factory.Create<INoteAccessor>();
                }
                return _noteAccessor;
            }
        }

        public NoteAccessorTests()
        {
            string folder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
            AccessorBase.SetPath(folder);
        }      

        [SetUp]
        public void Setup()
        {
            NoteAccessor.Setup(true);
        }

        [Test]
        public void NoteAccessor_FindAll_None()
        {
            Assert.AreEqual(0, NoteAccessor.FindAll().Length);
        }

        [Test]
        public void NoteAccessor_Create()
        {
            var list = NoteAccessor.FindAll();
            Assert.AreEqual(0, list.Length);

            var note = new Note()
            {
                    Title = "test title",
                    Body = "test body",
            };

            NoteAccessor.Save(note);

            Assert.AreEqual(1, NoteAccessor.FindAll().Length);
        }


        [Test]
        public void NoteAccessor_Update()
        {
            Assert.AreEqual(0, NoteAccessor.FindAll().Length);

            var note = new Note()
                {
                    Title = "test title",
                    Body = "test body",
                };

            NoteAccessor.Save(note);

            var list = NoteAccessor.FindAll();
            Assert.AreEqual(1, list.Length);

            Assert.AreEqual(note.Title, list[0].Title);
        }
    }
}

