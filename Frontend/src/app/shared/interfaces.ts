export interface IProduct{
  id: number;
  name: string;
  barcode: string;
  description: string;
  rate: number;
}


export interface IPagedResults<T> {
    pageSize: number;
    pageNumber: number;
    data: T[];
    succeeded: boolean;
    message: string;
    errors: string[];
  }

  export interface IRegister {
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    confirmPassword: string;
  }

  export interface ILogin {
    email: string;
    password: string;
  }
