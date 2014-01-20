namespace NServiceBus.Unicast.Config
{
    using Settings;
    using Transports;

    /// <summary>
    /// Default to MSMQ transport if no other transport has been configured. This can be removed when we introduce the modules concept
    /// </summary>
    public class DefaultTransportForHost : Configurator
    {
        public override void BeforeFinalizingConfiguration()
        {
            if (IsRegistered<ISendMessages>())
            {
                return;
            }

            if(Settings.SettingsHolder.GetOrDefault<TransportDefinition>("NServiceBus.Transport.SelectedTransport") != null)
            {
                return;
            }

            Configure.Instance.UseTransport<Msmq>();
        }
    }
}