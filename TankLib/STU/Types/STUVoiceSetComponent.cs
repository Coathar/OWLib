// Generated by TankLibHelper

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0x8745618A, 32)]
    public class STUVoiceSetComponent : STUEntityComponent
    {
        [STUField(0x8A4FF89C, 8)] // size: 16
        public teStructuredDataAssetRef<STUVoiceSet> m_voiceDefinition;

        [STUField(0x176FAE00, 24)] // size: 1
        public byte m_176FAE00 = 0x0;

        [STUField(0x30616A2F, 25)] // size: 1
        public byte m_30616A2F = 0x0;
    }
}
