import React, { useState, useEffect } from 'react';

function Search() {
    const [query, setQuery] = useState('');
    const [results, setResults] = useState([]);

    const fetchResults = async (searchTerm) => {
        try {
        const response = await fetch(`https://localhost:7018/api/Products/query?term=${encodeURIComponent(searchTerm)}`);
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            const data = await response.json();
            setResults(data.products);
            console.log(data);
        } catch (error) {
            console.error("Error fetching search results:", error);
            setResults([]);
        }
    };

    useEffect(() => {
        if (query.length < 2) {
            setResults([]);
            return;
        }

        const timeoutId = setTimeout(() => {
            fetchResults(query);
        }, 300);

        return () => clearTimeout(timeoutId);
    }, [query]);

    return (
        <div>
            <h2>Search Products</h2>
            <input
                type="text"
                placeholder="Type to search..."
                value={query}
                onChange={(e) => setQuery(e.target.value)}
            />
            <div>
                {results.length > 0 ? (
                    <ul>
                        {results.map((item) => (
                            <li key={item.id}>{item.name}</li>
                        ))}
                    </ul>
                ) : (
                    <p>No results found</p>
                )}
            </div>
        </div>
    );
}

export default Search;
