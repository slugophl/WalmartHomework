import { IItem } from "./item.model";

export interface ISearch {
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
