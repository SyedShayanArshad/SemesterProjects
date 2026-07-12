from flask_login import UserMixin
from database import Database

class User(UserMixin):
    def __init__(self, id, username, email, audit_count=0, is_premium=False):
        self.id = id
        self.username = username
        self.email = email
        self.audit_count = audit_count
        self.is_premium = is_premium

    def can_perform_audit(self):
        """Check if user can perform an audit (less than 3 or premium)"""
        return self.is_premium or self.audit_count < 3

    @staticmethod
    def get(user_id):
        """Get user by ID for Flask-Login"""
        db = Database()
        user_data = db.get_user_by_id(user_id)
        
        if user_data:
            return User(
                id=user_data['id'],
                username=user_data['username'],
                email=user_data['email'],
                audit_count=user_data['audit_count'],
                is_premium=bool(user_data['is_premium'])
            )
        return None