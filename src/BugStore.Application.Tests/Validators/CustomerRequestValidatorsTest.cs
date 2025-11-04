using AutoFixture;
using BugStore.Application.Services.Customers.Dto.Request;
using BugStore.Application.Validators;
using FluentAssertions;
using FluentValidation.TestHelper;

namespace BugStore.Application.Tests.Validators;
public class CustomerRequestValidatorsTest

{
    private readonly Fixture _fixture = new();
    private readonly CustomerRequestValidator _validator;

    public CustomerRequestValidatorsTest() => _validator = new CustomerRequestValidator();


    [Fact]    
    public void GivenANullNameField_WhenMakingARequestFromTheClient_ThenReturnAnError()
    {
        
        var request = _fixture
            .Build<CustomerRequest>()
            .With(x => x.Name, (string?)null)
            .Create();

        
        var result = _validator.TestValidate(request);

       
        result.Errors
            .Should()
            .NotBeNull();

        result.ShouldHaveValidationErrorFor(x => x.Name)
          .WithErrorMessage("Name é obrigatório");
    }


}
