import React, { Component } from 'react';

export class BlogCard extends Component {
  static displayName = BlogCard.name;

  render() {
    const { imageSource, name, description, url } = this.props;

    const cardImageStyle = {
      width: '100%',
      height: '180px',
      objectFit: 'cover',
      objectPosition: 'center',
      marginTop: '10px',
      borderRadius: '0.25rem'
    };

    return (
      <div className="card h-100" style={{ width: '18rem' }}>
        <img src={imageSource} className="card-img-top" style={cardImageStyle} alt={name} />
        <div className="card-body d-flex flex-column">
          <h5 className="card-title">{name}</h5>
          <p className="card-text mb-auto">{description}</p>
          <a href={url} className="btn btn-primary mt-3">Continue reading</a>
        </div>
      </div>
    );
  }
}
