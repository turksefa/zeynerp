using zeynerp.Core.Repositories.Tanimlamalar;

namespace zeynerp.Core.Interfaces
{
    public interface ITenantUnitOfWork
    {
        IStokGrupRepository StokGrupRepository { get; }
        IStokOzellikRepository StokOzellikRepository { get; }
        IBirimRepository BirimRepository { get; }
        IStokRepository StokRepository { get; }
    }
}