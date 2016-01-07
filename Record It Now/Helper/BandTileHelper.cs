using Microsoft.Band.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Record_It_Now.Helper {
  public class BandTileHelper {
    public IEnumerable<BandTile> CurrentBandTiles { get; set; }
    public async Task<IEnumerable<BandTile>> GetExistingTilesAsync() {
      CurrentBandTiles = await BandHelper.BandClient.TileManager.GetTilesAsync();
      return CurrentBandTiles;
    }
  }
}
