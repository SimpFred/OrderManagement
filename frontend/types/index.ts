export interface Product {
  id: number;
  name: string;
  quantity: number;
  price: number;
}

export interface Customer {
  id: number;
  name: string;
  email: string;
  address: string;
  zipCode: string;
  city: string;
  country: string;
}

export interface Order {
  id: number;
  customerId: number;
  customer: Customer;
  products: Product[];
  createdAt: string; // DateTime in C# is typically represented as a string in JSON
  shippedAt?: string; // Optional property
  totalCost: number;
}
