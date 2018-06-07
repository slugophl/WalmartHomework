import { IItem } from "./item.model";
import { IWalmartOpenApiBaseResponse } from "./walmartOpenApiBaseResponse.model";

export interface ISearch extends IWalmartOpenApiBaseResponse {
  query: string;
  sort: string;
  responseGroup: string;
  totalResults: number;
  start: number;
  numItems: number;
  items: IItem[];
  message: string;
  facets: any[];
}
