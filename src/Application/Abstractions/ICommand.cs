namespace Application.Abstractions;

public interface ICommand
{
}

public interface ICommnad<TResponse> : IBaseCommand
{
}

public interface IBaseCommand
{
}