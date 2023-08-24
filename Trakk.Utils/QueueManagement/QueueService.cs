namespace Trakk.Utils.QueueManagement;


public interface IQueueService
{
    QueueManager<string> TrakkerQueue { get; }
    QueueManager<int> AssetQueue { get; }
    QueueManager<int> VehicleQueue { get; }
    QueueManager<int> GeofenceQueue { get; }
}
public class QueueService : IQueueService
{
    public QueueManager<int> AssetQueue { get; } = new QueueManager<int>();
    public QueueManager<int> VehicleQueue { get; } = new QueueManager<int>();
    public QueueManager<string> TrakkerQueue { get; } = new QueueManager<string>();
    public QueueManager<int> GeofenceQueue { get; } = new QueueManager<int>();
}