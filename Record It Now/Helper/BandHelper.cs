using Microsoft.Band;
using System.Threading.Tasks;

namespace Record_It_Now.Helper {
  public class BandHelper {
    static public IBandInfo[] PairedBands { get; set; }
    static public IBandClient BandClient { get; set; }

    public string FirmwareVersion { get; set; }
    public string HardwareVersion { get; set; }


    public async Task<bool> LoadPairedBands() {
      PairedBands = await BandClientManager.Instance.GetBandsAsync();
      return true;
    }


    public async Task<bool> GetBandClient() {
      try {
        using (IBandClient bandClient = await BandClientManager.Instance.ConnectAsync(PairedBands[0])) {

        }
      } catch {
        return false;
      }
      return true;
    }

    public async void LoadBandVersion() {
      try {
        if (string.IsNullOrWhiteSpace(FirmwareVersion) || string.IsNullOrWhiteSpace(HardwareVersion)) {
          using (IBandClient bandClient = await BandClientManager.Instance.ConnectAsync(PairedBands[0])) {
            FirmwareVersion = await bandClient.GetFirmwareVersionAsync();
            HardwareVersion = await bandClient.GetHardwareVersionAsync();
          }
        }
        // do work with firmware & hardware versions
      } catch (BandException ex) {
        // handle any BandExceptions
      }
    }



  }
}
