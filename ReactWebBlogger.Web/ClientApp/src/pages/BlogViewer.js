import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';

const BlogViewer = ({ blogId }) => {
  const [blog, setBlog] = useState(null);
  const { id: routeBlogId } = useParams(); // Extract blogId from URL if available
  const effectiveBlogId = blogId || routeBlogId; // Use the prop if available, otherwise use the route parameter

  useEffect(() => {
    const fetchBlog = async () => {
      try {
        const res = await fetch(`api/blog/${effectiveBlogId}/`); // Use effectiveBlogId to fetch blog data
        const data = await res.json();
        setBlog(data);
      } catch (error) {
        console.error('Failed to fetch blog:', error);
      }
    };

    if (effectiveBlogId) {
      fetchBlog();
    }
  }, [effectiveBlogId]);

  if (!blog) {
    return <div>Loading...</div>;
  }

  return (
      <iframe id={"myiframe"}
        src={blog.url}
        title={blog.title || 'Blog Content'}
        scrolling='no'
        style={{
          display: 'block',
          width: '100%',
          height: blog.frameHeight,
          border: 'none' // This is optional to remove the border
      }}
     />
  );

};

export default BlogViewer;