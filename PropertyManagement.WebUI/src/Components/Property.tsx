import  { useState } from 'react';
import Space from './Space';

function Property({ property }) {
    const [isExpanded, setIsExpanded] = useState(false);

    return (
        <div className="property">
            <h3 onClick={() => setIsExpanded(!isExpanded)}>
                {property.propertyName} {isExpanded ? '?' : '?'}
            </h3>

            {isExpanded && (
                <div className="property-details">
                    <div className="features">
                        <li>
                            <strong>Features:</strong> 
                            <span>{property.features?.join(', ')}</span>
                        </li>                        
                    </div>

                    <div className="highlights">
                        <li>
                            <strong>Highlights:</strong>
                            <span>{property.highlights?.join(', ')}</span>
                        </li> 
                    </div>

                    <div className="transportation">
                        <li><strong>Transportation:</strong>
                        <span>
                        {property.transportation?.map((item, index) => (
                            <span key={index}>
                                {Object.values(item).map((value, i) => (<span key={i}>{value + " "}</span>))}
                            </span>                         
                        ))}
                        </span>
                        </li>
                    </div>

                    <Space key={"space"} space={property.spaces} />
                    
                </div>
            )}
        </div>
    );
}

export default Property;