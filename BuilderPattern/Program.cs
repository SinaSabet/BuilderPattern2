Builder builder=new ConcreteBuilder();

DirectorSignUp director=new DirectorSignUp();
director.SetBuilder(builder);
director.RunBuilder();
Console.ReadKey();


public abstract class SignUpServiceAbstraction
{
    public abstract void CreateUser();
    public abstract void SetUserPassword();
    public abstract void SendEmail();
}

public class SignUpService : SignUpServiceAbstraction
{
    public override void CreateUser()
    {
        Console.WriteLine("User Created ......");
    }

    public override void SendEmail()
    {
        Console.WriteLine("Email Sended ......");
    }

    public override void SetUserPassword()
    {
        Console.WriteLine("User Password Set .....");
    }
}


public abstract class Builder
{
    protected readonly SignUpServiceAbstraction _signUpService;

    public Builder()
    {
        _signUpService = new SignUpService();
    }

    public abstract void CreateUser();
    public abstract void SetUserPassword();
    public abstract void SendEmail();

    public virtual SignUpServiceAbstraction GetResult()
    {
        return new SignUpService();
    }
}

public class ConcreteBuilder : Builder
{
    public override void CreateUser()
    {
        _signUpService.CreateUser();
    }

    public override void SendEmail()
    {
        _signUpService.SendEmail();
    }

    public override void SetUserPassword()
    {
        _signUpService.SetUserPassword();
    }
}



public class DirectorSignUp
{
    private Builder _Builder;
    public void SetBuilder(Builder builder)
    {
        _Builder = builder; 
    }


    public void RunBuilder()
    {
        _Builder.CreateUser();
        _Builder.SetUserPassword();
        _Builder.SendEmail();
    }

}