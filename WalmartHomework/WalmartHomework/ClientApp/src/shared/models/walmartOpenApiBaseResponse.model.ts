export interface IWalmartOpenApiBaseResponse {
  statusCode: number;
  errors: IWalmartOpenApiError[];
}

export interface IWalmartOpenApiError {
  code: number;
  message: string;
}
