import React, { Component } from 'react';
import { BlogCard } from '../components/BlogCard.js';

export class Blogs extends Component {
  static displayName = Blogs.name;

  constructor(props) {
    super(props);
    this.state = {
      blogsData: [],
      isLoading: true,
      error: null,
    };
  }

  componentDidMount() {
    fetch('/api/blog/') // Replace with your actual API endpoint
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response.json();
      })
      .then(data => this.setState({ blogsData: data, isLoading: false }))
      .catch(error => this.setState({ error, isLoading: false }));
  }

  renderBlogCards() {
    const { blogsData, isLoading, error } = this.state;

    if (isLoading) {
      return <p>Loading blogs...</p>;
    }

    if (error) {
      return <p>Error loading blogs: {error.message}</p>;
    }

    return blogsData.map((blog, index) => (
      <div key={index} className="col-md-3">
        <BlogCard 
          imageSource={blog.imageSource} 
          name={blog.name} 
          description={blog.description}
          url={`blogs/${blog.id}/`} 
        />
      </div>
    ));
  }

  render() {
    return (
      <div className='row'>
        {this.renderBlogCards()}
      </div>
    );
  }
}
