using AppDelivery.Communication.Requests;

namespace AppDelivery.Application.UseCases.Review
{
    public interface IUpdateReviewUseCase
    {
        Task Execute(long Id, RequestReviewJson request);
    }
}
