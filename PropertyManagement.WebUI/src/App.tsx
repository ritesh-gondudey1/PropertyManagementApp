import { useState, useEffect } from 'react';
import Property from './Components/Property';
import './App.css';
import PropertyService from './Services/PropertyService';
import type { Properties } from './Types/Property';

function App() {
    const [properties, setProperties] = useState<Properties[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string  | null>(null);

    useEffect(() => {
    const fetchProperties = async () => {
      try {
        const data = await PropertyService.loadProperties();
        setProperties(data);
      } catch (err) {
        setError(err instanceof Error ? err.message : 'An unknown error occurred');
      } finally {
        setLoading(false);
      }
    };

    fetchProperties();
    }, []);

    if (loading) return <div className="loading">Loading properties...</div>;
    if (error) return <div className="error">Error: {error}</div>;

    return (
        <div className="app">
            <h1>Property Management Dashboard</h1>
            {properties.map(property => (
                <Property key={property.propertyName} property={property} />
            ))}
        </div>
    );
}

export default App;