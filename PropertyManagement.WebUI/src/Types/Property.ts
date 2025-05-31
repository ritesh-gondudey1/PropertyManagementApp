
export interface Properties {
  propertyId: string;
  propertyName: string;  
  features: string[];
  highlights: string[];
  transportation: TransportationItem[];
  spaces: Space[];  
}

export interface TransportationItem {
  type?: string;
  line?: string;
  distance?: string; 
  station?: string;
}

export interface Space {  
  rentRoll: RentRoll[];  
}

export interface RentRoll {
  month: string ; 
  rent: number ; 
}