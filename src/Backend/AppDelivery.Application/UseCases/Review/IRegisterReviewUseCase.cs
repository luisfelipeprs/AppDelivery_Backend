using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.Review;
public interface IRegisterReviewUseCase
{
    public Task<ResponseReviewJson> Execute(RequestReviewJson request);
}
