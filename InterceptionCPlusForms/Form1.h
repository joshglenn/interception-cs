#pragma once

namespace InterceptionCPlusForms {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Form1
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^  btnGetDevID;
	protected: 

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->btnGetDevID = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// btnGetDevID
			// 
			this->btnGetDevID->Location = System::Drawing::Point(185, 25);
			this->btnGetDevID->Name = L"btnGetDevID";
			this->btnGetDevID->Size = System::Drawing::Size(75, 23);
			this->btnGetDevID->TabIndex = 0;
			this->btnGetDevID->Text = L"Get Device ID";
			this->btnGetDevID->UseVisualStyleBackColor = true;
			this->btnGetDevID->Click += gcnew System::EventHandler(this, &Form1::btnGetDevID_Click);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(284, 262);
			this->Controls->Add(this->btnGetDevID);
			this->Name = L"Form1";
			this->Text = L"Form1";
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void btnGetDevID_Click(System::Object^  sender, System::EventArgs^  e) {

			 }
	};
}

