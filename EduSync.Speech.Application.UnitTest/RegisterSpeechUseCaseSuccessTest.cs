using EduSync.Speech.Application.Interfaces;
using EduSync.Speech.Application.Service;
using EduSync.Speech.Domain.Interfaces;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EduSync.Speech.Application.UnitTest
{
    public class RegisterSpeechUseCaseUnitTest
    {
        [Fact]
        public async Task RegisterSpeechUseCaseSuccessTest()
        {

            //Arrange
            //Use repository pattern to aggregate roots that are the only objects to be loaded from the repository

            Mock<ISpeechRepository> moqSpeechRepository = new Mock<ISpeechRepository>();
            moqSpeechRepository.Setup(m => m.CreateAsync(It.IsAny<Domain.SpeechAggregate.Speech>())).Returns(Task.FromResult<ISpeechRepository>(null)).Verifiable();

            /* Using UnitOFWork pattern, helps t treat aggregate rootsa as a unit for the purpose of datachanges */

            var moqUnitOfWork = new Mock<IUnitOfWork>();
            moqUnitOfWork.Setup(m => m.Commit()).Verifiable();


            //Command side of the CQRS pattern, no need for an output port
            //Register a new speech

            var registerSpeechCommand = new RegisterSpeechCommandMessage(
                "Microservices getting started",
                "A microservices from scratch online event",
                "https://github.com/Dontunee/BuildingMicroservicesThroughEventDrivenArchitecture",
                "2"
                );

           



            //Act
            //RegisterSpeechUseCase is the object under test
            IRegisterSpeechUseCase registerSpeechUseCase = new RegisterSpeechUseCase(moqUnitOfWork.Object, moqSpeechRepository.Object);

            await registerSpeechUseCase.Handle(registerSpeechCommand);

            //Assert
            //Verify that a new speech will be inserted into the database when savechanges is called

           // var data = new Mock<Domain.SpeechAggregate.Speech>();
            //moqSpeechRepository.Verify(m => m.CreateAsync(data.Object), Times.Once, "Create async must be called only once");

            //Verify that savechanges is called
            moqUnitOfWork.Verify(m => m.Commit(), Times.Once, "Commit must be called only once");



        }

        [Fact(DisplayName = "register speech use case with null speech throws an NullReferenceException")]
        public async Task RegisterSpeechUseCaseWithNullSpeechThrowsExceptionTest()
        {
            //Arrange
            Mock<IUnitOfWork> moqUnitOfWork = new Mock<IUnitOfWork>();

            var moqSpeechRepository = new Mock<ISpeechRepository>();

            //Act
            var useCase = new RegisterSpeechUseCase(moqUnitOfWork.Object, moqSpeechRepository.Object);

            //Assert 

            await Assert.ThrowsAsync<NullReferenceException>(() => useCase.Handle(null));

        }

        [Fact]
        public void RegisterSpeechWithTitleLessThan10CharactersThrowsDomainException()
        {
            //Arrange
            string title = "abc";

            //Act

            //Assert 
            Assert.Throws<DomainException>(() => new Domain.SpeechAggregate.Speech(title, It.IsAny<string>(),
                                                                   It.IsAny<string>(),
                                                                    It.IsAny<string>()));

        }
    }
}
