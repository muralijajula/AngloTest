import { CommodityDataPointDto } from "./CommodityDataPointDto";

export interface CommodityRecentHistoryDto {
  model: string;
  commodity: string;
  dataPoints: CommodityDataPointDto[];
}
