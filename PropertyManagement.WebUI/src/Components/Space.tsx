import React, { useState } from 'react';

function Space({ space }) {
    const [isExpanded, setIsExpanded] = useState(true);

    const months = [
        'January', 'February', 'March', 'April', 'May', 'June',
        'July', 'August', 'September', 'October', 'November', 'December'
    ] ;
  
    

    return (
        <div className="space">            
            <li><strong onClick={() => setIsExpanded(!isExpanded)}>
                {"Space " } {isExpanded ? '?' : '?'}
            </strong>
            </li>
            {isExpanded && (
                <div className="rent-roll">
                    {space?.map((r, i) => 
                        <div className="rent" key={i}>
                            <li><strong>{"Space " + String.fromCharCode(65 +i) }</strong></li>
                                <ul>                       
                                    {r.rentRoll.map((rent, index) =>                                         
                                        <li key={index}>{months[new Date(`${rent.month} 1, 2000`).getMonth()] + " : $" + rent.rent}</li>
                                     )}              
                                </ul>
                        </div>
                    )}  
                </div>
            )}
        </div>
    );
}

export default Space;