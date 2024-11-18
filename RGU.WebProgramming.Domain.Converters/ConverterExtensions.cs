namespace RGU.WebProgramming.Domain.Converters;

/// <summary>
/// 
/// </summary>
public static class ConverterExtensions
{
    
    #region MyFirstModel
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="domainMyFirstModel"></param>
    /// <returns></returns>
    public static RGU.WebProgramming.Grpc.AuthorModel Convert(
        this RGU.WebProgramming.Domain.Models.AuthorModel domainMyFirstModel)
    {
        ArgumentNullException.ThrowIfNull(domainMyFirstModel, nameof(domainMyFirstModel));
        
        return new RGU.WebProgramming.Grpc.AuthorModel
        {
            LastName = domainMyFirstModel.LastName,
            FirstName = domainMyFirstModel.FirstName
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="protobufMyFirstModel"></param>
    /// <returns></returns>
    public static RGU.WebProgramming.Domain.Models.AuthorModel ConvertBack(
        this RGU.WebProgramming.Grpc.AuthorModel protobufMyFirstModel)
    {
        ArgumentNullException.ThrowIfNull(protobufMyFirstModel, nameof(protobufMyFirstModel));
        
        return new RGU.WebProgramming.Domain.Models.AuthorModel
        {
            FirstName = protobufMyFirstModel.FirstName,
            LastName = protobufMyFirstModel.LastName
        };
    }
    
    #endregion
    
}