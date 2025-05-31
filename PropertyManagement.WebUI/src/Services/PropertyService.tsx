// src/services/propertyService.tsx
import axios, { AxiosError } from 'axios';
import type { Properties } from '../Types/Property';

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL ;


const PropertyService = {  
  loadProperties: async (): Promise<Properties[]> => {
    try {
      const response = await axios.get<Properties[]>(`${API_BASE_URL}/properties`);
      return response.data;
    } catch (error) {
      const axiosError = error as AxiosError;
      let errorMessage = 'Failed to load properties';
      
      if (axiosError.response) {
        errorMessage = `Server error: ${axiosError.response.status} - ${axiosError.response.statusText}`;
      } else if (axiosError.request) {       
        errorMessage = 'Network error - No response from server';
      } else {        
        errorMessage = `Request error: ${axiosError.message}`;
      }

      console.error('Error loading properties:', errorMessage);
      throw new Error(errorMessage);
    }
  },

  getPropertyById: async (id: string): Promise<Properties> => {
    try {
      const response = await axios.get<Properties>(`${API_BASE_URL}/properties/${id}`);
      return response.data;
    } catch (error) {
      const axiosError = error as AxiosError;
      let errorMessage = `Failed to load property with ID ${id}`;
      
      if (axiosError.response?.status === 404) {
        errorMessage = `Property with ID ${id} not found`;
      }

      console.error('Error loading property:', errorMessage);
      throw new Error(errorMessage);
    }
  }
};

export default PropertyService;