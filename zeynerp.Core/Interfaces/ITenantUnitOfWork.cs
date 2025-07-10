using zeynerp.Core.Repositories.SatinalmaYonetimi;
using zeynerp.Core.Repositories.Tanimlamalar;

namespace zeynerp.Core.Interfaces
{
    public interface ITenantUnitOfWork
    {
        IStokGrupRepository StokGrupRepository { get; }
        IStokOzellikRepository StokOzellikRepository { get; }
        IBirimRepository BirimRepository { get; }
        IStokRepository StokRepository { get; }
        IMalzemeTalepRepository MalzemeTalepRepository { get; }
        IMalzemeTalepleriRepository MalzemeTalepleriRepository { get; }
        ICariTurRepository CariTurRepository { get; }
        ICariRepository CariRepository { get; }
        IKDVRepository KDVRepository { get; }
        IOdemeVadeRepository OdemeVadeRepository { get; }
        IParaBirimRepository ParaBirimRepository { get; }
    }
}